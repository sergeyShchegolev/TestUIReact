import React, { Component } from "react";
import RoleDataService from "../../../services/role.service";
import { Routes, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import 'react-data-grid/lib/styles.css';
import DataGrid from 'react-data-grid';
import formStyles from "../forms.module.css";

export default class RolesList extends Component {
  constructor(props) {
    super(props);
    this.onChangeSearchTitle = this.onChangeSearchTitle.bind(this);
    this.retrieveRoles = this.retrieveRoles.bind(this);
    this.refreshList = this.refreshList.bind(this);
    this.setActiveRole = this.setActiveRole.bind(this);

    this.state = {
      roles: [],
      currentRole: null,
      currentIndex: -1,
      searchTitle: ""
    };
  }

  componentDidMount() {
    this.retrieveRoles();
  }

  onChangeSearchTitle(e) {
    const searchTitle = e.target.value;

    this.setState({
      searchTitle: searchTitle
    });
  }

  retrieveRoles() {
    RoleDataService.getAll()
      .then(response => {
        this.setState({
          roles: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  refreshList() {
    this.retrieveRoles();
    this.setState({
      currentRole: null,
      currentIndex: -1
    });
  }

  setActiveRole(role, index) {
    this.setState({
      currentRole: role,
      currentIndex: index
    });
  }

  searchTitle() {
    RoleDataService.findByTitle(this.state.searchTitle)
      .then(response => {
        this.setState({
          roles: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  render() {
    const { searchTitle, roles, currentRole, currentIndex } = this.state;

    const styles = {
      container: base => ({
        ...base,
        flex: 1,
        width: 200
      })
    };
    const columns = [
      { key: 'id', name: 'ID' },
      { key: 'title', name: 'Title' }
    ];
    
    const rows = [
      { id: 0, title: 'Example' },
      { id: 1, title: 'Demo' }
    ];
    return (
      <div className="list row"
      style = {{
        background: "#8E8E8E", 
        verticalalign: 'top',
        position: 'absolute',
        width: 900,
        height: 20,
        left: 0,
        top: 0,
        }}>
        <div style = {{background: "#8E8E8E", verticalAlign: 'top'}}> 
            <a href={"/addPhaseSequence"}>
                <button
                className={formStyles.createBtn}
                >
                  + Создать
                </button>
            </a>
        </div>
      <div className="list row">
        <div>
          <li className="nav-item">
            <Link to={"/addRole"} className="nav-link">
              Добавить
            </Link>
          </li>
        </div>

        <div className="col-md-8">
          <div className="input-group mb-3">
            <input
              type="text"
              className="form-control"
              placeholder="Search by title"
              value={searchTitle}
              onChange={this.onChangeSearchTitle}
            />
            <div className="input-group-append">
              <button
                className="btn btn-outline-secondary"
                type="button"
                onClick={this.searchTitle}
              >
                Search
              </button>
            </div>
          </div>
        </div>

        <div className="col-md-6">
          <h4>Роли</h4>
          <ul className="list-group">
            {roles &&
              roles.map((role, index) => (
                <li
                  className={
                    "list-group-item " +
                    (index === currentIndex ? "active" : "")
                  }
                  onClick={() => this.setActiveRole(role, index)}
                  key={index}
                >
                  {role.name}
                </li>
              ))}
          </ul>
        </div>
        {/* <DataGrid columns={columns} rows={rows} /> */}

        <div className="col-md-6">
          {currentRole ? (
            <div>
              <h4>Роль</h4>
              <div>
                <label>
                  <strong>Name:</strong>
                </label>{" "}
                {currentRole.name}
              </div>

              <a href={"/Role/" + currentRole.id}>
                  <button
                  className={formStyles.editbtn}
                  >
                    Редактировать
                  </button>
              </a>

            </div>
          ) : (
            <div>
              <br />
              <p>Please click on a Role...</p>
            </div>
          )}
        </div>


        <div className="list row"
                style = {{
                  background: "#8E8E8E", 
                  verticalalign: 'bottom',
                  width: 900,
                  height: 20,
                  top: 800,
                  }}>
                </div>

        <div style = {{background: "#8E8E8E"}}> 
        </div>
</div>
      </div>
    );
  }}