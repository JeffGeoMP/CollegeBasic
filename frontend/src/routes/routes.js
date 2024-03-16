import { Routes, Route } from "react-router-dom";

import * as View from "./ViewMapping";

function SwitchRoute() {
    return (
        <Routes>
            <Route path="/" element={<View.WelcomeView />}/>
            <Route path="/student" element={<View.StudentView />} />
            <Route path="/add/student" element={<View.WelcomeView />} />
            <Route path="*" element={<View.ErrorView />} />
        </Routes>
    );
}


export default SwitchRoute;