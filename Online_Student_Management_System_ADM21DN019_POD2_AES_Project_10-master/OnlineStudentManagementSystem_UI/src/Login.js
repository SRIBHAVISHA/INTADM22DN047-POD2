import React from 'react';
import { Link } from "react-router-dom";
import { Route, Redirect } from 'react-router'

class Login extends React.Component {
    constructor() {
    super();
    this.state = {
      input: {},
      errors: {}
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  handleChange(event) {
    let input = this.state.input;
    input[event.target.name] = event.target.value;
    this.setState({
      input
    });
  }
  handleSubmit(event) {
    event.preventDefault();
    if(this.validate()){
        console.log(this.state);
        if(this.state.input.username=='Admin'&& this.state.input.password=='123456')
                {
                    sessionStorage.setItem("role", "Admin");
                    alert('Wellcome to admin');
                    this.props.history.push("http://localhost:3000/Admin");
                }
               
        let input = {};
        input["username"] = "";
        input["password"] = "";
        input["role"] = "";
        this.setState({input:input});
    }
  }
  validate(){
      let input = this.state.input;
      let errors = {};
      let isValid = true;
      if (!input["username"]) {
        isValid = false;
        errors["name"] = "Please enter your user name.";
      }
     
      if (!input["password"]) {
        isValid = false;
        errors["password"] = "Please enter your password.";
      }
    //   if (!input["role"]) {
    //     isValid = false;
    //     errors["role"] = "--select--";
    //   }
      if (!input["password"]) {
        isValid = false;
        errors["password"] = "Please enter your password.";
      }
      if (typeof input["password"] !== "undefined") {
        if(input["password"].length < 6){
            isValid = false;
            errors["password"] = "Please add at least 6 charachter.";
        }
      }
      if (typeof input["password"] !== "undefined" && typeof input["confirm_password"] !== "undefined") {
        if (input["password"] != input["confirm_password"]) {
          isValid = false;
          errors["password"] = "Passwords don't match.";
        }
      } 
      this.setState({
        errors: errors
      });
      return isValid;
  }
  render() {
    return (
      <div>
        <form onSubmit={this.handleSubmit}>
        <div className="logo">
        <h2>Admin Sign In</h2>
               <img src="logo1.png" className="text-center" className="img-circle" alt="Cinque Terre" width="100" height="100" />
            </div>
            <br/>
          <div class="form-group">
            <label for="name">User Name:</label>
            <input 
              type="text" 
              name="username" 
              value={this.state.input.name}
              onChange={this.handleChange}
              class="form-control" 
              placeholder="Enter User name" 
              id="username" />
              <div className="text-danger">{this.state.errors.username}</div>
          </div>
          <div class="form-group">
            <label for="password">Password:</label>
            <input 
              type="password" 
              name="password" 
              value={this.state.input.password}
              onChange={this.handleChange}
              class="form-control" 
              placeholder="Enter password" 
              id="password" />
              <div className="text-danger">{this.state.errors.password}</div>
          </div><br></br>
         
          <button className="buttons" type="submit" name="Signin" style={{backgroundColor:'black'}} onChange={this.handleChange} >Sign In</button>
   
         
        </form>
      </div>
    );
  }
}
export default Login;