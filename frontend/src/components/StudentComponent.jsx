import React from "react";
import StudentService from "../services/studentService";
import {Loading, Report} from "notiflix";

class StudentComponent extends React.Component {

    studentService = new StudentService();

    constructor(props) {
        super(props);
        this.state = {
            students: []
        };
    }

    componentDidMount() {      
        Loading.pulse('Loading Students ...');
        this.studentService.getStudents(7).then((response) => {
            console.log(response.data);
            this.setState({students: response.data});
            Loading.remove();
        }).catch((error) => {
            Loading.remove();
            Report.failure('Error', error.response);
        });
    }

    render(){
        return (
            <div>
                <h2>Student Component</h2>
                <table>
                    <thead>
                        <tr>
                            <th>Student ID</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Age</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.students.map(student => 
                            <tr key={student.id}>
                                <td>{student.id}</td>
                                <td>{student.firstName}</td>
                                <td>{student.lastName}</td>
                                <td>{student.age}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }
}

export default StudentComponent;