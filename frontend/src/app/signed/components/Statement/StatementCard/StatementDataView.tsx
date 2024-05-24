export interface StatementDataViewProps {
    time: string;
    title: string;
    description: string;
}

export default function StatementDataView({
    time,
    title,
    description
}: StatementDataViewProps) {
    return (
        <div className="space-y-0.5 text-green-300">
            <span className="font-normal text-xs">{time}</span>
            <h2 className="font-bold text-xl">{title}</h2>
            <p className="font-normal text-xs">{description}</p>
        </div>
    );
}
