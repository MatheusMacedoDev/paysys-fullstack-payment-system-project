import { faUtensils } from '@fortawesome/free-solid-svg-icons';
import StatementIcon from './StatementIcon';
import StatementDataView, { StatementDataViewProps } from './StatementDataView';
import StatementValue, { StatementValueProps } from './StatementValue';
import Line from '../Line';

interface StatementCardProps
    extends StatementDataViewProps,
        StatementValueProps {}

export default function StatementCard({
    time,
    title,
    description,
    valueAmount
}: StatementCardProps) {
    return (
        <>
            <div className="flex justify-between items-center mb-3 pt-3">
                <div className="flex items-center gap-x-8">
                    <StatementIcon icon={faUtensils} />
                    <StatementDataView
                        time={time}
                        title={title}
                        description={description}
                    />
                </div>
                <StatementValue valueAmount={valueAmount} />
            </div>
            <Line />
        </>
    );
}
