import React from "react";
import StudentService from "../services/studentService";
import { Loading, Report } from "notiflix";

class StudentComponent extends React.Component {

	studentService = new StudentService();

	constructor(props) {
		super(props);
		this.state = {
			students: [],
			grades: [],
			gradeSelected: 0
		};
	}

	componentDidMount() {
		Loading.pulse('Loading Students ...');
		this.studentService.getGrade().then((response) => {
			this.setState({ grades: response.data });
			Loading.remove();
		}).catch((error) => {
			Loading.remove();
			Report.failure('Error', error);
		});
	}

	render() {
		return (
			<div>
				<h2>Student Component</h2>
				<span className="mt-3 p-2">Gets students according to their grade level</span>

				<div className="card mt-5 mb-3 p-3">
					<div className="card-header">
					<div className="d-flex justify-content-center">

					</div>
						<div className="row">
							<div className="col-md-4 offset-md-4">
								<div className="input-group">
									<select className="form-select" id="inputSelected" aria-label="Example select with button addon">
										<option defaultValue>Choose grade...</option>
										{this.state.grades.map(grade =>
											<option key={grade.grade} value={grade.grade}>{grade.gradeName}</option>
										)}
									</select>
									<button className="btn btn-outline-secondary" type="button">Buscar</button>
								</div>
							</div>
						</div>
					</div>
					<div className="card-body p-2 mt-2">
						<table className="table">
							<thead>
								<tr>
									<th scope="col">Student ID</th>
									<th scope="col">First Name</th>
									<th scope="col">Last Name</th>
									<th scope="col">Age</th>
								</tr>
							</thead>
							<tbody>
								{this.state.students.map(student =>
									<tr key={student.id}>
										<td>{student.firstName}</td>
										<td>{student.lastName}</td>
										<td>{student.age}</td>
									</tr>
								)}
							</tbody>
						</table>
					</div>
				</div>



			</div>
		);
	}
}

export default StudentComponent;