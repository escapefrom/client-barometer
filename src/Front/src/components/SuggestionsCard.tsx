import { Button, message, Spin } from "antd";
import React, { useEffect } from "react";
import { Suggestion } from "../api/client";
import { sessionClient } from "../api/httpClient";
import useApi from "../api/useApi";
import useChatContext from "./ChatHubContext";

type SuggestionsProps = {
    chatId: string;
};

const buttonStyle = {
    margin: "0.5rem",
};

export const SuggestionsCard: React.FC<SuggestionsProps> = ({ chatId }) => {
    const {
        loading,
        data: suggestions,
        fetch,
        setData
    } = useApi({
        initial: {},
        fetchData: sessionClient.suggestions,
    });

    useEffect(() => {
        fetch(chatId).catch((e) => message.error(e.message));
    }, [chatId, fetch]);

    const { connection } = useChatContext();

    useEffect(() => {
        connection.on("NewSuggestions", (message) => {
            setData(JSON.parse(message));
        });
        return () => connection.off("NewSuggestions");
    }, [connection, setData]);

    const onClick = (suggestion: Suggestion) => async () => {
        try {
            await sessionClient.send({
                chatId,
                text: suggestion.text,
                suggestionId: suggestion.id,
            });
        } catch (error) {
            message.error("Error sending message");
        }
    };

    if (loading) {
        return <Spin />;
    }

    const { messages } = suggestions;

    return (
        <>
            {messages?.map((message, index) => (
                <Button key={index} type="primary" style={buttonStyle} onClick={onClick(message)}>
                    {message}
                </Button>
            ))}
        </>
    );
};
