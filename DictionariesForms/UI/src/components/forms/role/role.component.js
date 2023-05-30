import React, { Component } from "react";
import RoleDataService from "../../../services/role.service";
import { withRouter } from '../../../common/with-router';
import Select from 'react-select';
import { useEffect } from 'react';
import formStyles from "../forms.module.css";

class Role extends Component {
  constructor(props) {
    super(props);
    this.myRef = React.createRef();

    this.onChangeName = this.onChangeName.bind(this);

    this.getRole = this.getRole.bind(this);
    this.updateRole = this.updateRole.bind(this);
    this.deleteRole = this.deleteRole.bind(this);
    this.createRoleVersion = this.createRoleVersion.bind(this);

    this.state = {
      currentRole: {
        id: null,
        name: '',
      },

      message: "",
    };
  }

  componentDidMount() {
    this.getRole(this.props.router.params.id);
  }

  getRole(id) {
    RoleDataService.get(id)
      .then(response => {
        this.setState({
          currentRole: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  updateRole() {
    var data = {
      id: this.state.currentRole.id,
      name: this.state.currentRole.name,
    };
    RoleDataService.update(data.id, data)
      .then(response => {
        console.log(response.data);
        this.setState({
          message: "Обновлено"
        });
      })
      .catch(e => {
        console.log(e);
      });
  }

  deleteRole() {    
    RoleDataService.delete(this.state.currentRole.id)
      .then(response => {
        console.log(response.data);
        this.props.router.navigate('/roles');
      })
      .catch(e => {
        console.log(e);
      });
  }

  createRoleVersion() {
    var data = {
      id: this.state.currentRole.id,
      name: this.state.currentRole.name,
      isActive: "true",
      versionNumber: parseInt(this.state.currentRole.versionNumber) + 1,
    };
    RoleDataService.create(data)
      .then(response => {
        console.log(response.data);
        this.setState({
          currentRole: data,
          message: "Версия создана"
        });
      })
      .catch(e => {
        console.log(e);
      });
  }

  onChangeName(e) { const name = e.target.value;
    this.setState(function(prevState) {
      return { currentRole: { ...prevState.currentRole, name: name }};
    });
  }

  render() {
    const { currentRole } = this.state;

    const styles = {
      container: base => ({
        ...base,
        flex: 1,
        width: 200
      })
    };
    return (
      <div>
        {currentRole && currentRole.id  ? (
          <div className="edit-form">
            <h4>Роль</h4>
            <form>

              <div className="form-group">
                <label htmlFor="name">Name</label>
                <input
                  type="text"
                  className="form-control"
                  id="name"
                  value={currentRole.name}
                  onChange={this.onChangeName}
                />
              </div>

              <div className="form-group">
                <label htmlFor="versionNumber">versionNumber</label>
                <label>{currentRole.versionNumber}</label>
              </div>
            </form>

            <button
              className="badge bg-danger"
              onClick={this.deleteRole}
            >
              Delete
            </button>

            <button
              type="submit"
              className="badge bg-success"
              onClick={this.updateRole}
            >
              Update
            </button>

            <p>{this.state.message}</p>
          </div>
        ) : (
          <div>
            <br />
            <p>Please click on a Role...</p>
          </div>
        )}
      </div>
    );
  }
}

export default withRouter(Role);