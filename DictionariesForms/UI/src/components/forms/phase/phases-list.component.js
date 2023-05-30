import React, { Component } from "react";
import PhaseDataService from "../../../services/phase.service";
import { Routes, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import formStyles from "../forms.module.css";

export default class PhasesList extends Component {
  constructor(props) {
    super(props);
    this.onChangeSearchTitle = this.onChangeSearchTitle.bind(this);
    this.retrievePhases = this.retrievePhases.bind(this);
    this.refreshList = this.refreshList.bind(this);
    this.setActivePhase = this.setActivePhase.bind(this);

    this.state = {
      phases: [],
      currentPhase: null,
      currentIndex: -1,
      searchTitle: ""
    };
  }

  componentDidMount() {
    this.retrievePhases();
  }

  onChangeSearchTitle(e) {
    const searchTitle = e.target.value;

    this.setState({
      searchTitle: searchTitle
    });
  }

  retrievePhases() {
    PhaseDataService.getAll()
      .then(response => {
        this.setState({
          phases: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  refreshList() {
    this.retrievePhases();
    this.setState({
      currentPhase: null,
      currentIndex: -1
    });
  }

  setActivePhase(phase, index) {
    this.setState({
      currentPhase: phase,
      currentIndex: index
    });
  }

  searchTitle() {
    PhaseDataService.findByTitle(this.state.searchTitle)
      .then(response => {
        this.setState({
          phases: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  render() {
    const { searchTitle, phases, currentPhase, currentIndex } = this.state;

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
            <a href={"/addPhase"}>
                <button
                className={formStyles.createBtn}
                >
                  + Создать
                </button>
            </a>
        </div>

        <div className="col-md-8">
          <div className="input-group mb-3">
            <input
              type="text"
              className="form-control"
              placeholder="Поиск"
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
          <h4>Фазы</h4>
          <ul className="list-group">
            {phases &&
              phases.map((phase, index) => (
                <li
                  className={
                    "list-group-item " +
                    (index === currentIndex ? "active" : "")
                  }
                  onClick={() => this.setActivePhase(phase, index)}
                  key={index}
                >
                  {phase.name}
                </li>
              ))}
          </ul>
        </div>

        <div className="col-md-6">
          {currentPhase ? (
            <div style = {{width: 800}}>
              <h4>Фаза</h4>
              <div>
                <label className={formStyles.dictElementName}>
                  <strong>Name:</strong>
                </label>{" "}
                <label
                  className={formStyles.dictElement}
                >
                {currentPhase.name}
                </label>
              </div>
              <div>
                <label className={formStyles.dictElementName}>
                  <strong>Contour:</strong>
                </label>{" "}
                <label
                  className={formStyles.dictElement}
                >
                {currentPhase.contourName}
                </label>
              </div>
              <div>
                <label className={formStyles.dictElementName}>
                  <strong>Compatibility:</strong>
                </label>{" "}
                <label
                  className={formStyles.dictElement}
                >
                {currentPhase.compatibilityName}
                </label>
              </div>
              <div>
                <label className={formStyles.dictElementName}>
                  <strong>Role:</strong>
                </label>{" "}
                <label
                  className={formStyles.dictElement}
                >
                {currentPhase.roleName}
                </label>
              </div>
              <div>
                <label className={formStyles.dictElementName}>
                  <strong>IsRequiredProcessPhase:</strong>
                </label>{" "}
                <label
                  className={formStyles.dictElement}
                >
                {currentPhase.isRequiredProcessPhase}
                </label>
              </div>
              <div>
                <label className={formStyles.dictElementName}>
                  <strong>PhaseOrder:</strong>
                </label>{" "}
                <label
                  className={formStyles.dictElement}
                >
                {currentPhase.phaseOrder}
                </label>
              </div>
              <div>
                <label className={formStyles.dictElementName}>
                  <strong>PhaseSequence:</strong>
                </label>{" "}
                <label
                  className={formStyles.dictElement}
                >
                {currentPhase.phaseSequenceName}
                </label>
              </div>
              <div>
                <label className={formStyles.dictElementName}>
                  <strong>PhaseStage:</strong>
                </label>{" "}
                <label
                  className={formStyles.dictElement}
                >
                {currentPhase.phaseStageName}
                </label>
              </div>
              <div>
                <label className={formStyles.dictElementName}>
                  <strong>VersionNumber:</strong>
                </label>{" "}
                <label
                  className={formStyles.dictElement}
                >
                {currentPhase.versionNumber}
                </label>
              </div>

              <a href={"/Phase/" + currentPhase.id}>
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
              <p>Please click on a Phase...</p>
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
    );
  }}