import { useState } from "react";

function Login() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const onEmailChange = (e) => {
        setEmail(e.target.value);
    };

    const onPasswordChange = (e) => {
        setPassword(e.target.value);
    };

    const loginHandle = async (e) => {
        e.preventDefault();
        fetch("login", {
            method: 'POST', headers: {
                'Content-Type': 'application/json',
            }, body: JSON.stringify({ email: email, password: password })
        }).then(async (res) => {
            const data = await res.json();
            localStorage.setItem("TOKEN_TYPE", data.tokenType);
            localStorage.setItem("X_ACCESS_TOKEN", data.accessToken);
            localStorage.setItem("X_REFRESH_TOKEN", data.refreshToken);
        }).catch(err => {
            console.log(err);
        });
    };

    return (
        <form onSubmit={loginHandle}>
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
                    value="Login"
                    className="btn btn-success btn-block"
                />
            </div>
        </form>
    );
}

export default Login;