import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import SelectItemModel from './SelectItemModel';
import { faChevronDown, faChevronUp } from '@fortawesome/free-solid-svg-icons';

interface SelectToggleProps {
    isDropdownOpened: boolean;
    selectedItemMenu?: SelectItemModel;
    placeholder: string;
    handleToggleDropdown: () => void;
}

export default function SelectToggle({
    isDropdownOpened,
    selectedItemMenu,
    placeholder,
    handleToggleDropdown
}: SelectToggleProps) {
    return (
        <div
            onClick={handleToggleDropdown}
            className={`
                    ${isDropdownOpened ? 'rounded-b-none' : 'rounded-b-full'}
                    ${isDropdownOpened ? 'rounded-t-3xl' : 'rounded-t-full'}
                    bg-gray-900 bg-opacity-0 border-green-300 border-2 w-full h-16 lg:h-14 px-8 flex items-center justify-between cursor-pointer
                `}
        >
            <p className="text-xl font-light text-green-300 select-none">
                {selectedItemMenu ? selectedItemMenu.displayText : placeholder}
            </p>
            {isDropdownOpened ? (
                <FontAwesomeIcon size="lg" icon={faChevronUp} />
            ) : (
                <FontAwesomeIcon size="lg" icon={faChevronDown} />
            )}
        </div>
    );
}
