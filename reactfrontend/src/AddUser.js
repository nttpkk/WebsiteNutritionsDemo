import React, { Component } from 'react';

class AddUser extends Component {
  constructor() {
    super();
    this.state = {
      userName: '',
      userBMI: '',
    };
  }

  onChange = (e) => {
    /*
      Because we named the inputs to match their
      corresponding values in state, it's
      super easy to update the state
    */
    this.setState({ [e.target.name]: e.target.value });
  }

  onSubmit = (e) => {
    e.preventDefault();
    const { userName, userBMI} = this.state;  // get our form data out of state
          let data = 
      {
        "userName": userName,
        "userBMI": userBMI,
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
  
  }

  render() {
    const { userName, userBMI} = this.state;
    return (
        <div>
          <p></p>
            <form onSubmit={this.onSubmit}>

                <input type="text" name="userName" value={userName}onChange={this.onChange} placeholder="Name"/>
                <input type="text" name="userBMI" value={userBMI}onChange={this.onChange} placeholder="BMI" />
                
                <button type="submit">Submit</button>
            </form>
      </div>
    );
  }
}
export default AddUser;