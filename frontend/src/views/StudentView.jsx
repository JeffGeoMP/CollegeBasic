import React from "react";
import Layout from "../template/Layout";
import StudentComponent from "../components/StudentComponent";

class StudentView extends React.Component {
    render() {
        return (
            <Layout>
                <StudentComponent/>
            </Layout>
        );
    }
}

export default StudentView;