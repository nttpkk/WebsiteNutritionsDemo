import React, { Component } from "react";
import Form from "./ListUsersForm";

class ListUsersApp extends Component {
  constructor(props) {
    super(props);

    this.state = {
      people: []
    };

    this.addPerson = this.addPerson.bind(this);
    this.deletePerson = this.deletePerson.bind(this);
  }

  addPerson(id, name, bmi) {
    this.setState(prevState => ({
      people: [...prevState.people, {id, name, bmi}]
    }));
  }

  componentDidMount() {
    this.getPeople();
  }

  getPeople() {
    let url = "https://localhost:44300/api/users"
    fetch(url) // https://jsonplaceholder.typicode.com/users
      .then(response => response.json())
      .then(response => this.setState({ people: response }))
      .catch(error => console.log(error));
  }

  deletePerson(userId) {
    return () => {
      this.setState(prevState => ({
        people: prevState.people.filter(person => person.userId !== userId)
        
      }));
      let url = "https://localhost:44300/api/users/" + userId;
      fetch(url, {
          method: "DELETE", // *GET, POST, PUT, DELETE, etc.
          mode: "cors", // no-cors, cors, *same-origin
          cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
          credentials: "same-origin", // include, *same-origin, omit
          headers: {
              "Content-Type": "application/json"
          },
          // redirect: "follow", // manual, *follow, error
          // referrer: "no-referrer", // no-referrer, *client
          // body: JSON.stringify(data), // body data type must match "Content-Type" header
        }); 
    }
  }

  render() {
    console.log(this.state);

    return (
      <div className="App">
        <Form addPerson={this.addPerson} />
        <table>
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>BMI</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {this.state.people.map((person) => {
              return (
                <tr key={person.userId}>
                  <th>{person.userId}</th>
                  <td>{person.userName}</td>
                  <td>{person.userBmi}</td>
                  <td>
                    <button onClick={this.deletePerson(person.userId)}>
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
export default ListUsersApp