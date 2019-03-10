import React, { Component } from "react";

class NewForm extends Component {
  constructor() {
    super();
    this.formSubmit = this.formSubmit.bind(this);
  }

  formSubmit(event) {
    event.preventDefault();
    const form = event.target;
    const id = form.elements["id"].value;
    const name = form.elements["name"].value;
    const bmi = form.elements["bmi"].value;
    this.props.addPerson(id, name, bmi);
    form.reset();
  }

  render() {
    return (
      <form onSubmit={this.formSubmit}>
        <input id="name" type="text" defaultValue="" placeholder="Name"/>
        <input id="bmi" type="text" defaultValue="" placeholder="BMI" />
        <input type="submit" value="add user" />
      </form>
    );
  }
}

export default NewForm;