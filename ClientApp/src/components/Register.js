import React, { useEffect, useState } from "react";
import { Link} from "react-router-dom";

export const Register = () => {
  return (
    <header id="signup" className="signup-section">
      <div className="container">
        <div className="row">
          <div className="col-sm-9 col-md-7 col-lg-5 mx-auto">
            <div className="card card-signin">
              <div class="card-body">
                <h5 class="card-title text-center">Register</h5>
                <form class="form-signin">
                  <div class="form-label-group">
                    <input
                      type="text"
                      id="inputUserame"
                      class="form-control form-control-custom"
                      placeholder="Username"
                      required
                      autofocus
                    />
                    <label for="inputUserame">Email Address</label>
                  </div>

                  <hr />

                  <div class="form-label-group">
                    <input
                      type="password"
                      id="inputPassword"
                      class="form-control form-control-custom"
                      placeholder="Password"
                      required
                    />
                    <label for="inputPassword">Password</label>
                  </div>

                  <div class="form-label-group">
                    <input
                      type="password"
                      id="inputConfirmPassword"
                      class="form-control form-control-custom"
                      placeholder="Password"
                      required
                    />
                    <label for="inputConfirmPassword">Confirm password</label>
                  </div>

                  <button
                    class="btn btn-lg btn-primary btn-block text-uppercase"
                    type="submit"
                  >
                    Register
                  </button>
                  <Link className="d-block text-center mt-2 small" to="/login">Sign In</Link>
                  <hr class="my-4" />
                  <button
                    class="btn btn-lg btn-google btn-block text-uppercase"
                    type="submit"
                  >
                    <i class="fab fa-google mr-2"></i> Sign up with Google
                  </button>
                  <button
                    class="btn btn-lg btn-facebook btn-block text-uppercase"
                    type="submit"
                  >
                    <i class="fab fa-facebook-f mr-2"></i> Sign up with Facebook
                  </button>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </header>
  );
};
