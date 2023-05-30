import React, { Component } from "react";
import PhaseDataService from "../../../services/phase.service";
import Select from 'react-select';
import formStyles from "../forms.module.css";

export default class AddPhase extends Component {
  constructor(props) {
    super(props);
    this.onChangeName = this.onChangeName.bind(this);
    this.onChangeContour = this.onChangeContour.bind(this);
    this.onChangeCompatibility = this.onChangeCompatibility.bind(this);
    this.onChangeRole = this.onChangeRole.bind(this);
    this.onChangeIsRequiredProcessPhase = this.onChangeIsRequiredProcessPhase.bind(this);
    this.onChangePhaseOrder = this.onChangePhaseOrder.bind(this);
    this.onChangeIsActive = this.onChangeIsActive.bind(this);
    this.onChangePhaseSequence = this.onChangePhaseSequence.bind(this);
    this.onChangePhaseStage = this.onChangePhaseStage.bind(this);

    this.savePhase = this.savePhase.bind(this);
    this.newPhase = this.newPhase.bind(this);

    this.state = {
      Name: '',
      Contour: '',
      Compatibility: '',
      Role: '',
      IsRequiredProcessPhase: '',
      PhaseOrder: '',
      IsActive: '',
      PhaseSequence: '',
      PhaseStage: '',

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



  onChangeName(e) { this.setState({ Name: e.target.value });  }
  onChangeContour(e) { this.setState({ Contour: e.value });  }
  onChangeCompatibility(e) { this.setState({ Compatibility: e.value });  }
  onChangeRole(e) { this.setState({ Role: e.value });  }
  onChangeIsRequiredProcessPhase(e) { this.setState({ IsRequiredProcessPhase: e.target.value });  }
  onChangePhaseOrder(e) { this.setState({ PhaseOrder: e.target.value });  }
  onChangeIsActive(e) { this.setState({ IsActive: e.target.value });  }
  onChangePhaseSequence(e) { this.setState({ PhaseSequence: e.value });  }
  onChangePhaseStage(e) { this.setState({ PhaseStage: e.value });  }

  savePhase() {
    var data = {
      Name: this.state.Name,
      ContourId: this.state.Contour,
      CompatibilityId: this.state.Compatibility,
      RoleId: this.state.Role,
      IsRequiredProcessPhase: this.state.IsRequiredProcessPhase,
      PhaseOrder: this.state.PhaseOrder,
      IsActive: 'true',
      PhaseSequenceId: this.state.PhaseSequence,
      PhaseStageId: this.state.PhaseStage,
    };

    PhaseDataService.create(data)
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

  newPhase() {
    this.setState({
      Name: '',
      Contour: '',
      Compatibility: '',
      Role: '',
      IsRequiredProcessPhase: '',
      PhaseOrder: '',
      IsActive: '',
      PhaseSequence: '',
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
      <div>
        {this.state.submitted ? (
          <div>
            <h4>Добавлено</h4>
            <button className="btn btn-success" onClick={this.newPhase}>
              Add
            </button>
          </div>
        ) : (
          <div>
            
              <label htmlFor="Name" style = {{width: 200}}>&nbsp; Name</label>
              <input
                style = {{width: 200}}
                type="text"
                id="Name"
                required
                value={this.state.Name}
                onChange={this.onChangeName}
                name="Name"
              />

            <div style={{ display: "flex" }}>
              <label htmlFor="Contour" style = {{width: 200}}>&nbsp; Contour</label>
              <Select 
                styles={styles}
                options={this.state.contours}                  
                id="Contour"
                required
                onChange={this.onChangeContour}
                name="Contour"/>
            </div>

            <div style={{ display: "flex" }}>
              <label htmlFor="Compatibility" style = {{width: 200}}>&nbsp; Compatibility</label>
              <Select 
                styles={styles}
                options={this.state.contours}                  
                id="Compatibility"
                required
                onChange={this.onChangeCompatibility}
                name="Compatibility"/>
            </div>

            <div style={{ display: "flex" }}>
              <label htmlFor="Role" style = {{width: 200}}>&nbsp; Role</label>
              <Select 
                styles={styles}
                options={this.state.roles}                  
                id="Role"
                required
                onChange={this.onChangeRole}
                name="Role"/>
            </div>

            <div style={{ display: "flex" }}>
              <label htmlFor="IsRequiredProcessPhase" style = {{width: 200}}>&nbsp; IsRequiredProcessPhase</label>
              <input
                type="text"
                style = {{width: 200}}
                id="IsRequiredProcessPhase"
                required
                value={this.state.IsRequiredProcessPhase}
                onChange={this.onChangeIsRequiredProcessPhase}
                name="IsRequiredProcessPhase"
              />
            </div>

            <div style={{ display: "flex" }}>
              <label htmlFor="PhaseOrder" style = {{width: 200}}>&nbsp; PhaseOrder</label>
              <input
                type="text"
                style = {{width: 200}}
                id="PhaseOrder"
                required
                value={this.state.PhaseOrder}
                onChange={this.onChangePhaseOrder}
                name="PhaseOrder"
              />
            </div>

            <div style={{ display: "flex" }}>
              <label htmlFor="phaseSequence" style = {{width: 200}}>&nbsp; PhaseSequence</label>
              <Select 
                styles={styles}
                options={this.state.phaseSequences}                  
                id="phaseSequence"
                required
                onChange={this.onChangePhaseSequence}
                name="phaseSequence"/>
            </div>

            <div style={{ display: "flex" }}>
              <label htmlFor="PhaseStage" style = {{width: 200}}>&nbsp; PhaseStage</label>
              <Select 
                styles={styles}
                options={this.state.phaseStages}                  
                id="PhaseStage"
                required
                onChange={this.onChangePhaseStage}
                name="PhaseStage"/>
            </div>

            &nbsp; <a href={"/Phases/"}>
                  <button
                  className={formStyles.delBtn}
                  >
                    Отмена
                  </button>
              </a>&nbsp;&nbsp;

            <button onClick={this.savePhase} 
              className={formStyles.updBtn}>
              Добавить
            </button>

            <p>{this.state.message}</p>
          </div>
        )}
      </div>
    );
  }
}