import { IconProp } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

interface StatementIconProps {
    icon: IconProp;
}

export default function StatementIcon({ icon }: StatementIconProps) {
    return (
        <div className="w-14 h-14 rounded-full bg-green-300 flex justify-center items-center">
            <FontAwesomeIcon className="text-green-950 text-2xl" icon={icon} />
        </div>
    );
}
