import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faLink
} from "@fortawesome/free-solid-svg-icons";
import { Alert } from "reactstrap";

const scheme = window.location.href.split("/")[0]+"//";

export class Home extends Component {
  static displayName = Home.name;
  constructor(props) {
    super(props);
    this.state = {
      longUrl: "",
      shortUrl: "",
      info: "",
      alert: false,
      show: false,
    };
    this.ShortenUrl = this.ShortenUrl.bind(this);
    this.ShowAlert = this.ShowAlert.bind(this);
    this.CopyToClipboard = this.CopyToClipboard.bind(this);
  }

  ShortenUrl(event) {
    event.preventDefault();
    let longUrl = this.state.longUrl;
    if (longUrl === "") {
      this.ShowAlert("Link cannot be empty!");
    } else {
      const formData = new FormData();
      formData.append("longUrl", longUrl);
      fetch("/api/url/generate", {
        method: "POST",
        body: formData
      }).then(res => {
        if (res.status === 400 || res.status === 404) {
          res.json().then(err => {
            this.setState({ show: false });
            this.ShowAlert(err.message);
          });
        } else {
          res.json().then(data => {
            let fLongUrl = data.longUrl;
            let fShortUrl = data.shortUrl;
           // console.log(fLongUrl);
           // console.log(fShortUrl);
            if(!fLongUrl.startsWith("http"))
            {
              fLongUrl = scheme+fLongUrl;
             // console.log(fLongUrl);
            }
            if(!fShortUrl.startsWith("http"))
            {
              fShortUrl = scheme+fShortUrl;
             // console.log(fShortUrl);
            }
            this.setState({
              longUrl: fLongUrl,
              shortUrl: fShortUrl ,
              show: true
            });
          });
        }
      });
    }
  }

  CopyToClipboard = (e) => {
    this.copyInput.select();
    document.execCommand('copy');
    e.target.focus();
    this.ShowAlert("Link copied to clipboard!")
  };

  ShowAlert(message) {
    this.setState({ alert: !this.state.alert, info: message });
    const timer = setTimeout(() => {
      this.setState({ alert: !this.state.alert });
    }, 2000);
    return () => clearTimeout(timer);
  }

  render() {
    return (
      <>
        <header id="signup" className="signup-section">
          <div className="container">
            <div className="row">
              <div
                className="col-md-10 col-lg-8 mx-auto text-center"
                style={{ height: "38rem" }}
              >
                <div style={{ color: "white", paddingBottom: "10px" }}>
                  <FontAwesomeIcon icon={faLink} size="8x" />
                </div>
                <h2 className="text-white mb-5">
                  Create Concise, Click-Worthy Links
                </h2>

                <form onSubmit={this.ShortenUrl} className="form-inline d-flex">
                  <input
                    type="text"
                    className="form-control flex-fill mr-0 mr-sm-2 mb-3 mb-sm-0"
                    id="inputLink"
                    placeholder="Enter Long Link..."
                    value={this.state.longUrl}
                    onChange={e => {
                      this.setState({ show:false, longUrl: e.target.value });
                    }}
                    autoComplete="off"
                  />
                  <button type="submit" className="btn btn-primary mx-auto">
                    Shorten
                  </button>
                </form>
                <br />
                {this.state.show && (
                  <div className="form-inline d-flex">
                    <div className="input-group mb-3">
                      {/* <div className="input-group-prepend">
                        <span
                          className="input-group-text"
                          id="addon-wrapping"
                        >
                          <a rel="noopener noreferrer" target="_blank" href={this.state.longUrl}>{this.state.longUrl}</a>
                        </span>
                      </div> */}
                      <input
                        type="text"
                        className="form-control"
                        placeholder=""
                        aria-label={this.state.shortUrl}
                        aria-describedby="copy-link"
                        style={{ width: "40rem", cursor:"pointer" }}
                        autoComplete="off"
                        value={this.state.shortUrl}
                        ref={(input) => this.copyInput = input}
                        onChange={(e) => {console.log("never change")}}
                        onClick={(e) => {window.open(e.target.value, "_blank")}}
                      />
                      <div className="input-group-append">
                        <button
                          className="btn btn-outline-secondary"
                          type="button"
                          id="copy-link"
                          style={{ backgroundColor: "#64a19d" }}
                          onClick= {this.CopyToClipboard}
                        >
                          Copy
                        </button>
                      </div>
                    </div>
                  </div>
                )}
                <div className="alert-parent">
                  <Alert color="warning" fade={true} isOpen={this.state.alert}>
                    {this.state.info}
                  </Alert>
                </div>
              </div>
            </div>
          </div>
        </header>
      </>
    );
  }
}
