import React, { useState, useEffect } from 'react';
import { Form, FormGroup, Label, Col, Button } from 'reactstrap'
import styles from './Task.module.css';
import { useForm } from "react-hook-form";
import axios from 'axios';
import TaskSubmitMessage from './TaskSubmitMessage';

const Task = (props) => {
    const { register, handleSubmit, errors } = useForm();
    const [tasks, setTasks] = useState([]);
    const [selectedTaskDescription, setSelectedTaskDescription] = useState("");
    const [formStatus, setFormStatus] = useState({ isLoading: false, submitResponse: null });

    useEffect(() => {
        axios.get('/api/task')
        .then(function (response) {
            setTasks(response.data);
        })
        .catch(function () {
            props.history.push('/error');
        }) }, []);

    const onTaskChange = (e) => {
        const dsecription = tasks.find(x => x.taskId === +e.target.value)?.description ?? ""
        setSelectedTaskDescription(dsecription);
    }

    const onSubmit = (data) => {
        setFormStatus({ ...formStatus, isLoading: true});
        axios.post('/api/task/SubmitTaskSolution', { taskId: parseInt(data.taskId), solution: data.solution })
            .then(function (response) {
                setFormStatus({ ...formStatus, isLoading: false, submitResponse: response.data });
            })
            .catch(function () {
                props.history.push('/error');
            });
    };

    return (
        <div className={styles.solveContainer}>
            <h2>Solve</h2>
            <Form onSubmit={handleSubmit(onSubmit)}>
                <FormGroup row>
                    <Label sm={{ size: 2, offset: 2 }}>Select task</Label>
                    <Col sm={5}>
                        <select name="taskId" className="form-control" onChange={onTaskChange} ref={register({ required: true })}>
                            <option></option>
                            {tasks.map(task => { return <option key={task.taskId} value={task.taskId}>{task.name}</option> })}
                        </select>
                        {errors.task && <p className={styles.inputError}>Task not selected</p>}
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label sm={{ size: 2, offset: 2 }}>Description</Label>
                    <Col sm={5}>
                        <p>{selectedTaskDescription}</p>
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label sm={{ size: 2, offset: 2 }}>Solution code</Label>
                    <Col sm={5}>
                        <textarea name="solution" className="form-control" rows={4} type="textarea" ref={register({ required: true })} />
                        {errors.taskSolution && <p className={styles.inputError}>Code solution is required</p>}
                    </Col>
                </FormGroup>
                <FormGroup check row>
                    <Col sm={{ size: 5, offset: 4 }}>
                        <Button disabled={formStatus.isLoading} color="primary" type="submit">Submit</Button>
                    </Col>
                </FormGroup>
            </Form>
            {formStatus.submitResponse != null ? < TaskSubmitMessage response={formStatus.submitResponse} /> : null}
        </div>
    );
}
export default Task;