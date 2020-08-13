import React from 'react';

const TopUserItems = (props) => {
    return (
        props.topUsers.map(topUser => {
            return <tr key={topUser.name}>
                <td>{topUser.name}</td>
                <td>{topUser.taskCount}</td>
                <td>{topUser.tasks}</td>
            </tr>
        })
    );
}

export default TopUserItems;