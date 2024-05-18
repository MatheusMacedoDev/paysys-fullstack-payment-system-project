import { useEffect, useState } from 'react';
import SelectItemModel from './SelectItemModel';
import SelectToggle from './SelectToggle';
import MenuDropdown from './MenuDropdown';
import { useFormContext } from 'react-hook-form';

interface SelectProps {
    name: string;
    placeholder: string;
    data: Array<SelectItemModel>;
    onChange: (selectedItem: SelectItemModel) => void;
}

export default function Select({
    name,
    placeholder,
    data,
    onChange
}: SelectProps) {
    const [selectedItem, setSelectedItem] = useState<SelectItemModel>();
    const [isDropdownOpened, setIsDropdownOpened] = useState<boolean>(false);

    const { setValue } = useFormContext();

    function toggleDropdown() {
        setIsDropdownOpened(!isDropdownOpened);
    }

    function closeDropdown() {
        setIsDropdownOpened(false);
    }

    function selectItem(item: SelectItemModel) {
        setSelectedItem(item);
        onChange(item);
    }

    useEffect(() => {
        setValue(name, selectedItem?.value);
    }, [selectedItem, setValue, name]);

    return (
        <div className="relative">
            <SelectToggle
                isDropdownOpened={isDropdownOpened}
                selectedItemMenu={selectedItem}
                placeholder={placeholder}
                handleToggleDropdown={toggleDropdown}
            />
            <MenuDropdown
                isDropdownOpened={isDropdownOpened}
                data={data}
                handleCloseDropdown={closeDropdown}
                handleSelectItem={selectItem}
            />
        </div>
    );
}
