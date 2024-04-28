import { useState } from "react";

function Register() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const onEmailChange = (e) => {
        setEmail(e.target.value);
    };

    const onPasswordChange = (e) => {
        setPassword(e.target.value);
    };

    const registerHandle = async (e) => {
        e.preventDefault();
        await fetch("register", {
            method: 'POST', headers: {
                'Content-Type': 'application/json',
            }, body: JSON.stringify({ email: email, password: password })
        }).catch(err => {
            console.log(err);
        });
    };

    return (
        <form onSubmit={registerHandle}>
            <div className="mb-3">
                <input
                    type="email"
                    name="email"
                    value={email}
                    onChange={onEmailChange}
                    className="form-control"
                    placeholder="email"
                />
            </div>
            <div className="mb-3">
                <input
                    type="password"
                    name="password"
                    value={password}
                    onChange={onPasswordChange}
                    className="form-control"
                    placeholder="password"
                />
            </div>
            <div>
                <input
                    type="submit"
                    value="Register"
                    className="btn btn-success btn-block"
                />
            </div>
        </form>
    );
}

export default Register;