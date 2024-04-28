import { useEffect } from "react";
import { useState } from "react";
import DeleteOrder from "./DeleteOrder";

function OrderList() {
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        getOrders();
    }, []);

    const getOrders = async () => {
        const tokenType = localStorage.getItem("TOKEN_TYPE");
        const token = localStorage.getItem("X_ACCESS_TOKEN");
        await fetch("order", {
            method: 'get', headers: {
                'Content-Type': 'application/json',
                'Authorization': tokenType + ' ' + token
            }
        }).then(async (res) => {
            const data = await res.json();
            setOrders(data);
        }).catch(err => {
            console.log(err);
        });
    };

    return (
        <div className="mt-5 wrapper">
            <h2 className="mb-4">Orders</h2>
            <table className="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Name</th>
                    </tr>
                </thead>
                <tbody>
                    {orders.map((order, index) => {
                        return (
                            <tr key={index}>
                                <th scope="row">{order.id}</th>
                                <td>{order.name}</td>
                                <DeleteOrder id={order.id} />
                            </tr>
                        );
                    })}
                </tbody>
            </table>
        </div>
    );
}

export default OrderList;