import React, { useState, useEffect } from 'react';
import { Table } from 'reactstrap';
import styles from './TopUsers.module.css'
import TopListItems from './TopUserItems'
import axios from 'axios';

const TopUsers = (props) => {
    const [topUsers, setTopUsers] = useState([]);

    useEffect(() => {
        axios.get('/api/topUsers')
            .then(function (response) {
                setTopUsers(response.data);
            })
            .catch(function () {
                props.history.push('/error');
            })
    }, []);

    return (
        <div className={styles.topContainer}>
            <h2>TOP 3</h2>
            <Table bordered>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Success solutions</th>
                        <th>Tasks</th>
                    </tr>
                </thead>
                <tbody>
                    <TopListItems topUsers={topUsers} />
                </tbody>
            </Table>
        </div>
    );
}

export default TopUsers;