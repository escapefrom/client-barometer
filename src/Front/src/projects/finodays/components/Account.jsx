import * as React from 'react';
import { Accordion, Container, Card, ListGroup, Table } from "react-bootstrap";

class Operation extends React.Component {
    render() {
        return (
            <Table borderless style={{ textAlign: "center", verticalAlign: "bottom", marginTop: 4 }}>
                <tbody>
                    <tr>
                        <td rowspan="2" style={{ verticalAlign: "middle", width: "7%", fontSize: "32px", fontWeight: "bold", color: this.props.type === "+" ? "green" : "red" }}>{this.props.type}</td>
                        <td style={{ textAlign: "left" }}>{this.props.category}</td>
                        <td rowspan="2" style={{ verticalAlign: "middle", width: "32%", color: this.props.type === "+" ? "green" : "red", fontWeight: "bold", fontSize: "24px" }}>{this.props.sum} р.</td>
                        <td rowspan="2" style={{ verticalAlign: "middle", width: "10%" }}>{this.props.time}</td>
                    </tr>
                    <tr>
                        <td style={{ textAlign: "left", fontSize: "24px", fontWeight: "bold" }}>{this.props.target}</td>
                    </tr>
                </tbody>
            </Table>
        )
    }
}

class Day extends React.Component {
    render() {
        return (
            <div>
                <div style={{ fontSize: "24px", marginLeft: "3%" }}>{this.props.date}</div>
                <div>{this.props.operations.map(operation => (
                    <Operation type={operation.type} category={operation.category} target={operation.target} sum={operation.sum} time={operation.time} />
                ))}</div>
            </div>
        )
    }
}

class Account extends React.Component {
    render() {
        var accounts = [
            { id: 1, label: "Account 1", balance: "9999" },
            { id: 2, label: "Account 2", balance: "4464643" }
        ];


        var operations_per_day = [
            {
                "date": "Вчера",
                operations: [
                    { type: "+", target: "Затинацкий И.В.", category: "Переводы", sum: "1223", time: "11:21" },
                    { type: "-", target: "Пятерочка", category: "Супермаркеты", sum: "1223", time: "09:43" }
                ]
            },
            {
                "date": "14.09.2021",
                operations: [
                    { type: "-", target: "KFC", category: "Фастфуд", sum: "1223", time: "19:43" },
                    { type: "-", target: "Делимобиль", category: "Каршеринг", sum: "1223", time: "12:22" },
                    { type: "+", target: "Николаев И.В.", category: "Переводы", sum: "1223", time: "07:00" }
                ]
            }
        ];

        return (
            <Container>
                {accounts.map(tab => (
                    <Accordion defaultActiveKey="0" style={{ marginBottom: 20 }}>
                        <Card>
                            <Accordion.Toggle as={Card.Header} eventKey="0" style={{ fontSize: "18px" }}>
                                <div style={{ fontSize: "22px" }}>Счет: {tab.label}</div>
                                <div>Баланс: {tab.balance}</div>
                            </Accordion.Toggle>
                            <Accordion.Collapse eventKey="0">
                                <ListGroup>
                                    {operations_per_day.map(day => (
                                        <Day date={day.date} operations={day.operations} />
                                    ))}
                                    {/* <ListGroup.Item as={Operation} ></ListGroup.Item>
                                    <ListGroup.Item as={Operation}></ListGroup.Item> */}
                                </ListGroup>
                            </Accordion.Collapse>
                        </Card>
                    </Accordion>
                ))}
            </Container>
        )
    }
}

export default Account;