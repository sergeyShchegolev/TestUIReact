import React, { Component } from "react";
import PhaseDataService from "../../../services/phase.service";
import { withRouter } from '../../../common/with-router';
import Select from 'react-select';
import { useEffect } from 'react';
import formStyles from "../forms.module.css";

class Phase extends Component {
  constructor(props) {
    super(props);
    this.myRef = React.createRef();

    this.onChangeName = this.onChangeName.bind(this);
    this.onChangeContour = this.onChangeContour.bind(this);
    this.onChangeCompatibility = this.onChangeCompatibility.bind(this);
    this.onChangeRole = this.onChangeRole.bind(this);
    this.onChangeIsRequiredProcessPhase = this.onChangeIsRequiredProcessPhase.bind(this);
    this.onChangePhaseOrder = this.onChangePhaseOrder.bind(this);
    this.onChangePhaseSequence = this.onChangePhaseSequence.bind(this);
    this.onChangePhaseStage = this.onChangePhaseStage.bind(this);

    this.getPhase = this.getPhase.bind(this);
    this.updatePhase = this.updatePhase.bind(this);
    this.deletePhase = this.deletePhase.bind(this);
    this.createPhaseVersion = this.createPhaseVersion.bind(this);

    this.state = {
      currentPhase: {
        id: null,
        name: '',
        contourId: '',
        contourName: '',
        compatibilityId: '',
        compatibilityName: '',
        roleId: '',
        roleName: '',
        isRequiredProcessPhase: false,
        phaseOrder: '',
        isActive: false,
        phaseSequenceId: '',
        phaseSequenceName: '',
        phaseStageId: '',
        phaseStageName: '',
        versionNumber: 0,
      },

      roles: [],
      contours: [],
      phaseSequences: [],
      phaseStages: [],

      message: "",
    };

    PhaseDataService.getAllRoles()
    .then(response => {
      this.setState({
        roles: response.data
      });
      console.log(response.data);
    })
    .catch(e => {
      console.log(e);
    });

    PhaseDataService.getAllContours()
    .then(response => {
      this.setState({
        contours: response.data
      });
      console.log(response.data);
    })
    .catch(e => {
      console.log(e);
    });

    PhaseDataService.getAllPhaseSequences()
    .then(response => {
      this.setState({
        phaseSequences: response.data
      });
      console.log(response.data);
    })
    .catch(e => {
      console.log(e);
    });

    PhaseDataService.getAllPhaseStages()
    .then(response => {
      this.setState({
        phaseStages: response.data
      });
      console.log(response.data);
    })
    .catch(e => {
      console.log(e);
    });
  }

  componentDidMount() {
    this.getPhase(this.props.router.params.id);
  }

  getPhase(id) {
    PhaseDataService.get(id)
      .then(response => {
        this.setState({
          currentPhase: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  updatePhase() {
    var data = {
      id: this.state.currentPhase.id,
      name: this.state.currentPhase.name,
      contourId: this.state.currentPhase.contourId,
      compatibilityId: this.state.currentPhase.compatibilityId,
      roleId: this.state.currentPhase.roleId,
      isRequiredProcessPhase: this.state.currentPhase.isRequiredProcessPhase,
      phaseOrder: this.state.currentPhase.phaseOrder,
      isActive: this.state.currentPhase.isActive,
      phaseSequenceId: this.state.currentPhase.phaseSequenceId,
      phaseStageId: this.state.currentPhase.phaseStageId,
      versionNumber: parseInt(this.state.currentPhase.versionNumber),
    };
    PhaseDataService.update(data.id, data)
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

  deletePhase() {    
    PhaseDataService.delete(this.state.currentPhase.id)
      .then(response => {
        console.log(response.data);
        this.props.router.navigate('/Phases');
      })
      .catch(e => {
        console.log(e);
      });
  }

  createPhaseVersion() {
    var data = {
      id: this.state.currentPhase.id,
      name: this.state.currentPhase.name,
      contourId: this.state.currentPhase.contourId,
      compatibilityId: this.state.currentPhase.compatibilityId,
      roleId: this.state.currentPhase.roleId,
      isRequiredProcessPhase: this.state.currentPhase.isRequiredProcessPhase,
      phaseOrder: this.state.currentPhase.phaseOrder,
      isActive: this.state.currentPhase.isActive,
      phaseSequenceId: this.state.currentPhase.phaseSequenceId,
      phaseStageId: this.state.currentPhase.phaseStageId,
      versionNumber: parseInt(this.state.currentPhase.versionNumber) + 1,
    };
    PhaseDataService.create(data)
      .then(response => {
        console.log(response.data);
        this.setState({
          currentPhase: data,
          message: "Версия создана"
        });
      })
      .catch(e => {
        console.log(e);
      });
  }

  onChangeName(e) { const name = e.target.value;
    this.setState(function(prevState) {
      return { currentPhase: { ...prevState.currentPhase, name: name }};
    });
  }
  onChangeContour(e) { const contour = e?.value;
    this.setState(function(prevState) {
      return { currentPhase: { ...prevState.currentPhase, contour: contour }};
    });
  }
  onChangeCompatibility(e) { const compatibility = e?.value;
    this.setState(function(prevState) {
      return { currentPhase: { ...prevState.currentPhase, compatibility: compatibility }};
    });
  }
  onChangeRole(e) { const role = e?.value;
    this.setState(function(prevState) {
      return { currentPhase: { ...prevState.currentPhase, roleId: role }};
    });
  }
  onChangeIsRequiredProcessPhase(e) { const isRequiredProcessPhase = e.target.checked;
    this.setState(function(prevState) {
      return { currentPhase: { ...prevState.currentPhase, isRequiredProcessPhase: isRequiredProcessPhase }};
    });
  }
  onChangePhaseOrder(e) { const phaseOrder = e.target.value;
    this.setState(function(prevState) {
      return { currentPhase: { ...prevState.currentPhase, phaseOrder: phaseOrder }};
    });
  }
  onChangePhaseSequence(e) { const phaseSequence = e?.value;
    this.setState(function(prevState) {
      return { currentPhase: { ...prevState.currentPhase, phaseSequenceId: phaseSequence }};
    });
  }
  onChangePhaseStage(e) { const phaseStage = e?.value;
    this.setState(function(prevState) {
      return { currentPhase: { ...prevState.currentPhase, phaseStageId: phaseStage }};
    });
  }

  render() {
    const { currentPhase } = this.state;
    const inputsWidth = 300;
    const labelStyles = {width: 200, 'margin-bottom': '0.5cm'};
    const selectStyles = {
      container: base => ({
        ...base,
        flex: 1,
        width: inputsWidth
      })
    };
    return (
      <div>
        {currentPhase && currentPhase.id  ? (
          <div>
            <h4>&nbsp;Фаза</h4>
              
                <label htmlFor="name" style = {labelStyles}>&nbsp; Name</label>
                <input
                  style = {{width: inputsWidth}}
                  type="text"
                  id="name"
                  value={currentPhase.name}
                  onChange={this.onChangeName}
                />

              <div style={{ display: "flex" }}>
                <label htmlFor="Contour" style = {labelStyles}>&nbsp; Contour</label>
                <Select 
                  styles={selectStyles}
                  options={this.state.contours}                  
                  id="Contour"
                  required
                  onChange={this.onChangeContour}
                  name="Contour"
                  defaultValue={{ value: currentPhase.contourId, label: currentPhase.contourName }}
                  isClearable={true}
                  />
                  </div>

              <div style={{ display: "flex" }}>
              <label htmlFor="Compatibility" style = {labelStyles}>&nbsp; Compatibility</label>
              <Select 
                styles={selectStyles}
                  options={this.state.contours}                  
                  id="Compatibility"
                  onChange={this.onChangeCompatibility}
                  name="Compatibility"
                  defaultValue={{ value: currentPhase.compatibilityId, label: currentPhase.compatibilityName }}
                  isClearable={true}
                  />
              </div>

              <div style={{ display: "flex" }}>
                <label htmlFor="Role" style = {labelStyles}>&nbsp; Role</label>
                <Select 
                styles={selectStyles}
                  options={this.state.roles}                  
                  id="Role"
                  onChange={this.onChangeRole}
                  name="Role"
                  defaultValue={{ value: currentPhase.roleId, label: currentPhase.roleName }}
                  isClearable={true}
                  />
              </div>

                <label htmlFor="isRequiredProcessPhase" style = {labelStyles}>&nbsp; isRequiredProcessPhase</label>
                <input
                  type="checkbox"
                  id="isRequiredProcessPhase"
                  checked={currentPhase.isRequiredProcessPhase}
                  onChange={this.onChangeIsRequiredProcessPhase}
                />
<br></br>
                <label htmlFor="phaseOrder" style = {labelStyles}>&nbsp; phaseOrder</label>
                <input
                  style = {{width: inputsWidth}}
                  type="text"
                  id="phaseOrder"
                  value={currentPhase.phaseOrder}
                  onChange={this.onChangePhaseOrder}
                />

              <div style={{ display: "flex" }}>
                <label htmlFor="phaseSequence" style = {labelStyles}>&nbsp; phaseSequence</label>
                <Select 
                styles={selectStyles}
                  options={this.state.phaseSequences}                  
                  id="phaseSequence"
                  onChange={this.onChangePhaseSequence}
                  name="phaseSequence"
                  defaultValue={{ value: currentPhase.phaseSequenceId, label: currentPhase.phaseSequenceName }}
                  isClearable={true}
                  />
              </div>

              <div style={{ display: "flex" }}>
                <label htmlFor="phaseStage" style = {labelStyles}>&nbsp; phaseStage</label>
                <Select 
                styles={selectStyles}
                  options={this.state.phaseStages}                  
                  id="phaseStage"
                  onChange={this.onChangePhaseStage}
                  name="phaseStage"
                  defaultValue={{ value: currentPhase.phaseStageId, label: currentPhase.phaseStageName }}
                  isClearable={true}
                  />
              </div>

              <div className="form-group">
                <label htmlFor="versionNumber" style = {labelStyles}>&nbsp; versionNumber</label>
                <label>{currentPhase.versionNumber}</label>
              </div>

            <button
              className={formStyles.delBtn}
              onClick={this.deletePhase}
            >
              Удалить
            </button>&nbsp;&nbsp;

            <button
              type="submit"
              className={formStyles.updBtn}
              onClick={this.updatePhase}
            >
              Обновить
            </button>&nbsp;&nbsp;

            <button
              type="submit"
              className={formStyles.updBtn}
              onClick={this.createPhaseVersion}
            >
              Добавить версию
            </button>

            <p>{this.state.message}</p>
          </div>
        ) : (
          <div>
            <br />
            <p>Please click on a Phase...</p>
          </div>
        )}
      </div>
    );
  }
}

export default withRouter(Phase);