import React, { Component } from "react";
import Form from "./ListFoodsForm";

class ListFoodsApp extends Component {
  constructor(props) {
    super(props);

    this.state = {
      food: []
    };

    this.addFood = this.addFood.bind(this);
    this.deleteFood = this.deleteFood.bind(this);
  }

  addFood(name, foodCarb, foodProt, foodFat) {
    // this.setState(prevState => ({food: [...prevState.food, { name, foodCarb, foodProt, foodFat }]}));
    this.setState({name, foodCarb, foodProt, foodFat}); // This works really well!
        let data = 
        {
          "foodName": name,
          "foodCarbonhydrate": foodCarb,
          "foodProtein": foodProt,
          "foodFat": foodFat,

      };
      let url = "https://localhost:44300/api/foods/";
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

  componentDidMount() {
    this.getfood();
  }

  getfood() {
    let url = "https://localhost:44300/api/foods"
    fetch(url) // https://jsonplaceholder.typicode.com/users
      .then(response => response.json())
      .then(response => this.setState({ food: response }))
      .catch(error => console.log(error));
  }

  deleteFood(foodId) {
    return () => {
      this.setState(prevState => ({food: prevState.food.filter(food => food.foodId !== foodId)}));
      let url = "https://localhost:44300/api/foods/" + foodId;
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
        <Form addFood={this.addFood} />
        <table>
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>Carbs</th>
              <th>Prots</th>
              <th>Fats</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {this.state.food.map((food) => {
              return (
                <tr key={food.foodId}>
                  <th>{food.foodId}</th>
                  <td>{food.foodName}</td>
                  <td>{food.foodCarbonhydrate}</td>
                  <td>{food.foodProtein}</td>
                  <td>{food.foodFat}</td>
                  <td>
                    <button onClick={this.deleteFood(food.foodId)}>
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
export default ListFoodsApp