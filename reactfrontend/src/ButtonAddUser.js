import React, { Component } from 'react';

class ButtonAddUser extends Component {

  AddUser(){
    let data = 
    {
      "userName": "ReactTEST", 
  };

  let url = "https://localhost:44300/api/users";
  fetch(url, {
      method: "POST", // *GET, POST, PUT, DELETE, etc.
      mode: "cors", // no-cors, cors, *same-origin
      cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
      credentials: "same-origin", // include, *same-origin, omit
      headers: {
          "Content-Type": "application/json"
      },
      redirect: "follow", // manual, *follow, error
      referrer: "no-referrer", // no-referrer, *client
      body: JSON.stringify(data), // body data type must match "Content-Type" header
  });

  alert("Fetch-request has been sent!");
}

  render() {
    return (
      <div>
          <p></p>
          <button onClick={this.AddUser} type="button" class="btn btn-primary">Add new user to Database</button>
          <p></p>
      </div>
    );
  }
}

export default ButtonAddUser;