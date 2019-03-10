import React, { Component } from "react";
import Form from "./OldForm123";

class OldApp123 extends Component {
  constructor(props) {
    super(props);

    this.state = {
      people: []
    };

    this.addPerson = this.addPerson.bind(this);
    this.deletePerson = this.deletePerson.bind(this);
  }

  addPerson(name, email) {
    this.setState(prevState => ({
      people: [...prevState.people, { name, email }]
    }));
  }

  componentDidMount() {
    this.getPeople();
  }

  getPeople() {
    fetch("https://jsonplaceholder.typicode.com/users")
      .then(response => response.json())
      .then(response => this.setState({ people: response }))
      .catch(error => console.log(error));
  }

  deletePerson(email) {
    return () => {
      this.setState(prevState => ({
        people: prevState.people.filter(person => person.email !== email)
      }));
    };
  }

  render() {
    console.log(this.state);

    return (
      <div className="App">
        <Form addPerson={this.addPerson} />
        <table>
          <thead>
            <tr>
              <th>LP</th>
              <th>USER</th>
              <th>EMAIL</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {this.state.people.map((person, index) => {
              return (
                <tr key={person.email}>
                  <th>{index + 1}</th>
                  <td>{person.name}</td>
                  <td>{person.email}</td>
                  <td>
                    <button onClick={this.deletePerson(person.email)}>
                      Delete
                    </button>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    );
  }
}
export default OldApp123