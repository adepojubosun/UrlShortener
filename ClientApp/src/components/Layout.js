import React, { Component } from 'react';
import { NavMenu } from './NavMenu';
import { Link} from "react-router-dom";

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
          {this.props.children}
          <footer className="bg-black small text-center text-white-50">
          <div className="container">Copyright &copy; UrlShortener 2020</div>
          <Link to="/terms">
            <small>Terms and Conditions</small>
          </Link>
        </footer>
      </div>
    );
  }
}
