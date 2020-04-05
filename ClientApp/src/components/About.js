import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faPercent,
  faHandshake,
  faMagnet
} from "@fortawesome/free-solid-svg-icons";
import { Link} from "react-router-dom";

export default class About extends Component {
  static displayName = About.name;
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <>
        <section className="masthead">
          <div className="container d-flex h-100 align-items-center">
            <div className="mx-auto text-center">
              <h3 className="text-white mx-auto mt-2 mb-3">
                Build and protect your brand using powerful, recognizable short
                links.
              </h3>
              <Link
                to="/register"
                className="btn btn-primary js-scroll-trigger"
              >
                Register!
              </Link>
            </div>
          </div>
        </section>

        <section className="contact-section bg-black">
          <div className="container">
            <div className="row">
              <div className="col-md-4 mb-3 mb-md-0">
                <div className="card py-4 h-100">
                  <div className="card-body text-center">
                    <i className="fas fa-map-marked-alt text-primary mb-2"></i>
                    <h3 className="text-uppercase m-0">
                      <FontAwesomeIcon icon={faPercent} />
                    </h3>
                    <hr className="my-4" />
                    <div className="small text-black-50">Get Traction</div>
                  </div>
                </div>
              </div>

              <div className="col-md-4 mb-3 mb-md-0">
                <div className="card py-4 h-100">
                  <div className="card-body text-center">
                    <i className="fas fa-envelope text-primary mb-2"></i>
                    <h3 className="text-uppercase m-0">
                      <FontAwesomeIcon icon={faHandshake} />
                    </h3>
                    <hr className="my-4" />
                    <div className="small text-black-50">Inspire Trust</div>
                  </div>
                </div>
              </div>

              <div className="col-md-4 mb-3 mb-md-0">
                <div className="card py-4 h-100">
                  <div className="card-body text-center">
                    <i className="fas fa-mobile-alt text-primary mb-2"></i>
                    <h3 className="text-uppercase m-0">
                      <FontAwesomeIcon icon={faMagnet} />
                    </h3>
                    <hr className="my-4" />
                    <div className="small text-black-50">Become Attractive</div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>
      </>
    );
  }
}
