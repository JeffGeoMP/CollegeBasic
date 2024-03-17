import axios from "axios";
import environment from "../helpers/environment";

class StudentService {

    getGrade = () => {
        return axios({
            method: "GET",
            url: `${environment.servicesUrl}Student/api/get/grade`,
            data: null,
            headers: {
                "Content-Type": "application/json",
                "Authorization": `${environment.appKey}`
            },
            timeout: 5000
        });
    }

    getStudents = (grade) => {
        return axios({
            method: "GET",
            url: `${environment.servicesUrl}Student/api/get/${grade}`,
            data: null,
            headers: {
                "Content-Type": "application/json",
                "Authorization": `${environment.appKey}`
            },
            timeout: 5000
        });
    }

    addStudent = (student) => {
        return axios({
            method: "POST",
            url: `${environment.servicesUrl}Student/api/add`,
            data: student,
            headers: {
                "Content-Type": "application/json",
                "Authorization": `${environment.appKey}`
            },
            timeout: 5000
        });
    }
}
export default StudentService;