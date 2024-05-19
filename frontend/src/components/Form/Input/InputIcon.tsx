import { IconProp } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

interface InputIconProps {
    icon?: IconProp;
}

export default function InputIcon({ icon }: InputIconProps) {
    return (
        icon && (
            <div className="w-[50px] lg:w-[42px] h-[50px] lg:h-[42px] rounded-full bg-green-300 absolute right-[9px] top-[7px] flex items-center justify-center">
                <FontAwesomeIcon className="text-green-950 w-2/5" icon={icon} />
            </div>
        )
    );
}
