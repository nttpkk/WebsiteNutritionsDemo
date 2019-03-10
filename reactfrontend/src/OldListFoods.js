import React, { Component } from 'react';

class ListFoods extends Component {
    constructor(props) {
        super(props);
        console.log("ListFoods.constructor");
        this.state = { downloaded: false, data: null };
    }
    componentDidMount() {
        console.log("ListFoods.componentDidMount");
        let komponentti = this;
        fetch('https://localhost:44300/api/foods')
        .then(response => response.json())
        .then(json => {
            console.log("Fetch-call ready!");
            console.log(json);
            komponentti.setState({downloaded: true, data: json});
            console.log("SetState-routine has been called.");
        });
        console.log("ListFoods.componentDidMount: fetch-call made");
    }
  render() {
    console.log("ListFoods.render");
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
            let name = this.state.data[index].foodName;
            let carbs = this.state.data[index].foodCarbonhydrate;
            let prots = this.state.data[index].foodProtein;
            let fats = this.state.data[index].foodFat;
            users.push(
              <tr>
                {/* <th scope="row">{index+1}</th> */}
                <td>{name}</td>
                <td>{carbs}</td>
                <td>{prots}</td>
                <td>{fats}</td>
              </tr>);
        }
        return (
            <div>
                <p></p>
                <h1>Foods of Nutrition.com</h1>
                <p></p>

                <table class="table table-dark">
                    <thead>
                        <tr>
                        <th scope="col">A</th>
                        <th scope="col">B</th>
                        <th scope="col">C</th>
                        <th scope="col">D</th>
                        <th scope="col">E</th>
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

export default ListFoods;