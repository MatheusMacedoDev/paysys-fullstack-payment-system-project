import Line from './Line';

interface StatementDateMarker {
    date: string;
    className?: string;
}

export default function StatementDateMarker({
    date,
    className
}: StatementDateMarker) {
    return (
        <div className={className}>
            <h4 className="font-light text-green-300 text-sm mb-4">
                {date.toUpperCase()}
            </h4>
            <Line />
        </div>
    );
}
