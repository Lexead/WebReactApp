import { useState } from "react";

function CreateOrder() {
    const [name, setName] = useState('');

    const onNameChange = (e) => {
        setName(e.target.value);
    };

    const createOrderHandle = async (e) => {
        e.preventDefault();
        const tokenType = localStorage.getItem("TOKEN_TYPE");
        const token = localStorage.getItem("X_ACCESS_TOKEN");
        await fetch("order", {
            method: 'POST', headers: {
                'Content-Type': 'application/json',
                'Authorization': tokenType + ' ' + token
            }, body: JSON.stringify({ name: name })
        }).catch(err => {
            console.log(err);
        });
    };

    return (
        <form onSubmit={createOrderHandle}>
            <div className="mb-3">
                <input
                    type="name"
                    name="name"
                    value={name}
                    onChange={onNameChange}
                    className="form-control"
                    placeholder="name"
                />
            </div>
            <div>
                <input
                    type="submit"
                    value="Create order"
                    className="btn btn-success btn-block"
                />
            </div>
        </form>
    );
}

export default CreateOrder;