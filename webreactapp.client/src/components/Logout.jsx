
function Logout() {
    const logoutHandle = async (e) => {
        e.preventDefault();
        await fetch("logout", {
            method: 'POST', headers: {
                'Content-Type': 'application/json'
            }
        }).then(async (res) => {
            localStorage.clear();
        }).catch(err => {
            console.log(err);
        });

    };

    return (
        <form onSubmit={logoutHandle}>
            <div>
                <input
                    type="submit"
                    value="Logout"
                    className="btn btn-success btn-block"
                />
            </div>
        </form>
    );
}

export default Logout;