import React from "react"
import { Alert } from "reactstrap";

const TaskSubmitMessage = (props) => {

    return (
        <div style={{ marginTop: "20px" }}>
            {

                props.response.isSuccess
                    ? <Alert color="success">Success </Alert>
                    : <Alert color="danger">{props.response.error}</Alert>
            }
        </div>
    );
}

export default TaskSubmitMessage;