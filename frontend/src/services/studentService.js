import axios from "axios";
import enviroment from "../helpers/enviroment";

class StudentService {

    getStudents = (grade) => {

        console.log(`${enviroment.appKey}/Student/api/get/${grade}`)

        return axios({
            method: "GET",
            url: `${enviroment.servicesUrl}/Student/api/get/${grade}`,
            data: null,
            headers: {
                "Content-Type": "application/json",
                "Access-Control-Allow-Origin": "*",
                "Authorization": `${enviroment.appKey}`
            },
            timeout: 5000
        });
    }

    addStudent = (student) => {
        return axios({
            method: "POST",
            url: `${enviroment.servicesUrl}/Student/api/add`,
            data: student,
            headers: {
                "Content-Type": "application/json",
                "Access-Control-Allow-Origin": "*",
                "Authorization": `${enviroment.appKey}`
            },
            timeout: 5000
        });
    }
}
export default StudentService;