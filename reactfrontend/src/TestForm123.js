import React, { Component } from "react";

class Form extends Component {
  constructor() {
    super();
    this.formSubmit = this.formSubmit.bind(this);
  }

  formSubmit(event) {
    event.preventDefault();
    const form = event.target;
    const email = form.elements["email"].value;
    const name = form.elements["name"].value;
    this.props.addPerson(name, email);
    form.reset();
  }

  render() {
    return (
      <form onSubmit={this.formSubmit}>
        <input id="name" type="text" defaultValue="" placeholder="Name..."/>
        <input id="email" type="text" defaultValue="" placeholder="Email..." />
        <input type="submit" value="submit" />
      </form>
    );
  }
}

export default Form;