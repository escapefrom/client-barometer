import React, { CSSProperties } from "react";

export const StatsPage: React.FC = () => {
    return <div style={containerStyle}>
        <iframe title="Stats" width="100%" height="800" src="https://app.powerbi.com/view?r=eyJrIjoiNTQzMTkwZDQtMTcyNi00YWQ0LWIxYTMtOWM4MTY3ZWNlYTgwIiwidCI6ImIyODYzNTEyLWUzNmMtNDIwYi1hZTk4LTY1ZGEyYzc5ODg4MCJ9" frameBorder={0} allowFullScreen={true}></iframe>
    </div>;
};


const containerStyle: CSSProperties = {
    padding: "0",
};
