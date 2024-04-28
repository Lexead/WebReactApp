function DeleteOrder({ id }) {
    const deleteOrderHandle = async (e) => {
        e.preventDefault();
        const tokenType = localStorage.getItem("TOKEN_TYPE");
        const token = localStorage.getItem("X_ACCESS_TOKEN");
        await fetch(`order/${id}`, {
            method: 'DELETE', headers: {
                'Content-Type': 'application/json',
                'Authorization': tokenType + ' ' + token
            }
        }).catch(err => {
            console.log(err);
        });

    };

    return (
        <form onSubmit={deleteOrderHandle}>
            <div>
                <input
                    type="submit"
                    value="Delete"
                    className="btn btn-success btn-block"
                />
            </div>
        </form>
    );
}

export default DeleteOrder;