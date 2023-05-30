import React, { Component } from "react";
import RoleDataService from "../../../services/role.service";
import Select from 'react-select';
import formStyles from "../forms.module.css";

export default class AddRole extends Component {
  constructor(props) {
    super(props);
    this.onChangeName = this.onChangeName.bind(this);

    this.saveRole = this.saveRole.bind(this);
    this.newRole = this.newRole.bind(this);

    this.state = {
      Name: '',

      message: "",
    };
  }

  onChangeName(e) { this.setState({ Name: e.target.value });  }

  saveRole() {
    var data = {
      Name: this.state.Name,
      IsActive: 'true',
    };
    RoleDataService.create(data)
       .then(response => {
        this.setState({
          message: "Добавлено"
        });        
        console.log(response.data);
      }) 
      .catch(e => {
        console.log(e);
      });
  }

  newRole() {
    this.setState({
      Name: '',
    });
  }

  render() {
    const styles = {
      container: base => ({
        ...base,
        flex: 1,
        width: 200
      })
    };
    return (
      <div className="submit-form">
        {this.state.submitted ? (
          <div>
            <h4>Добавлено</h4>
            <button className="btn btn-success" onClick={this.newRole}>
              Add
            </button>
          </div>
        ) : (
          <div>
            <div className="form-group">
              <label htmlFor="Name">Name</label>
              <input
                type="text"
                className="form-control"
                id="Name"
                required
                value={this.state.Name}
                onChange={this.onChangeName}
                name="Name"
              />
            </div>

            <button onClick={this.saveRole} className="btn btn-success">
              Submit
            </button>
            <p>{this.state.message}</p>
          </div>
        )}
      </div>
    );
  }
}