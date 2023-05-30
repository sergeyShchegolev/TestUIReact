import http from "../http-common";

class PhaseDataService {
  getAll() {
    return http.get("/phase");
  }

  get(id) {
    return http.get(`/phase/${id}`);
  }

  create(data) {
    return http.post("/phase", data);
  }

  update(id, data) {
    return http.put(`/phase/${id}`, data);
  }
  
  delete(id) {
    return http.delete(`/phase/${id}`);
  }

  getAllRoles() {
    return http.get(`/Role`);
  }

  getAllContours() {
    return http.get(`/Contour`);
  }

  getAllPhaseSequences() {
    return http.get(`/PhaseSequence`);
  }

  getAllPhaseStages() {
    return http.get(`/PhaseStage`);
  }
}

export default new PhaseDataService();