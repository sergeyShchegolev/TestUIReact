import React, { Component } from "react";
import { Routes, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import {Navigation} from 'react-minimal-side-navigation';
import 'react-minimal-side-navigation/lib/ReactMinimalSideNavigation.css';
import { Text, View } from 'react-native';

import Phase from "./components/forms/phase/phase.component";
import PhasesList from "./components/forms/phase/phases-list.component";
import AddPhase from "./components/forms/phase/add-phase.component";

import Role from "./components/forms/role/role.component";
import RolesList from "./components/forms/role/roles-list.component";
import AddRole from "./components/forms/role/add-role.component";


class App extends Component {

  render() {
    return (
      <> 
      <View style={[{flexDirection:'row'}]}>
        <div style={{
          flexDirection:'row',
          height: 1000,
          color: "#FFFFFF",
          background: "#525252",
          border: "1px solid #9E9E9E"
          }}
          >
        <View style={[{
          flexDirection:'row',
          height: 320,
          color: "#FFFFFF",
          background: "#626262",
          border: "1px solid #9E9E9E"
          }]}>
          <div>
            <nav>
              <Link to={"/Phases"} className="navbar-brand">
                Фазы
              </Link>
            </nav>
            <nav>
              <Link to={"/Roles"} className="navbar-brand">
                Роли
              </Link>
            </nav>

          </div>
        </View>
        </div>
        <View style={[{
          justifyContent:'space-evenly', 
          marginVertical:10, 
          
          fontFamily: 'Open Sans',
          fontWeight: 600,
          fontSize: 16,
          lineHeight: 33,
          /* or 206% */
          
          
          color: "#000000",
          }]}>
                 
          <Routes>
            <Route path="/*" element={<PhasesList/>} />

            <Route path="/Phases" element={<PhasesList/>} />
            <Route path="/Phase/:id" element={<Phase/>} />
            <Route path="/addPhase" element={<AddPhase/>} />
            
            <Route path="/Roles" element={<RolesList/>} />
            <Route path="/Role/:id" element={<Role/>} />
            <Route path="/addRole" element={<AddRole/>} />

          </Routes>

        </View>
      </View>
      </>
    );
  }
}

export default App;