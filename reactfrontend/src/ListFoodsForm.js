import React, { Component } from "react";

class ListFoodsForm extends Component {
  constructor() {
    super();
    this.formSubmit = this.formSubmit.bind(this);
  }

  formSubmit(event) {
    event.preventDefault();
    const form = event.target;
    // const id = form.elements["id"].value;
    const name = form.elements["name"].value;
    const foodCarb = form.elements["foodCarb"].value;
    const foodProt = form.elements["foodProt"].value;
    const foodFat = form.elements["foodFat"].value;
    this.props.addFood(name, foodCarb, foodProt, foodFat);
    form.reset();
  }

  render() {
    return (
      <form onSubmit={this.formSubmit}>
        <input id="name" type="text" defaultValue="" placeholder="Name"/>
        <input id="foodCarb" type="text" defaultValue="" placeholder="foodCarb" />
        <input id="foodProt" type="text" defaultValue="" placeholder="foodProt" />
        <input id="foodFat" type="text" defaultValue="" placeholder="foodFat" />
        <input type="submit" value="add food" />
      </form>
    );
  }
}

export default ListFoodsForm;