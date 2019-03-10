import React, { Component } from 'react';

class ListUsers extends Component {
    constructor(props) {
        super(props);
        console.log("ListUsers.constructor");
        this.state = { downloaded: false, data: null };
    }
    componentDidMount() {
        console.log("ListUsers.componentDidMount");
        let komponentti = this;
        fetch('https://localhost:44300/api/users')
        .then(response => response.json())
        .then(json => {
            console.log("Fetch-call ready!");
            console.log(json);
            komponentti.setState({downloaded: true, data: json});
            console.log("SetState-routine has been called.");
        });
        console.log("ListUsers.componentDidMount: fetch-call made");
    }
  render() {
    console.log("ListUsers.render");
    if (this.state.downloaded === false) {
        return (
            <div>
                <h1>Wait few moments, Loading data..</h1>
            </div>
        );
    }
    else {
        let users = [];
        for (let index = 0; index < this.state.data.length; index++) {
            let name = this.state.data[index].userName;
            users.push(
              <tr>
                <th scope="row">{index+1}</th>
                <td>{name}</td>
              </tr>);
        }
        return (
            <div>
                <p></p>
                <h1>Users of Nutrition.com</h1>
                <p></p>

                <table class="table table-dark">
                    <thead>
                        <tr>
                        <th scope="col">#</th>
                        <th scope="col">User Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {users}
                    </tbody>
                </table>    
            </div>
        );
    }    
  }
}

export default ListUsers;