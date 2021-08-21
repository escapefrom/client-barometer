import { CSSProperties } from "react";

export const StatsPage: React.FC = () => {
    return <div style={containerStyle}>
        <iframe title="Stats"/>
    </div>;
};


const containerStyle: CSSProperties = {
    padding: "2rem",
};
