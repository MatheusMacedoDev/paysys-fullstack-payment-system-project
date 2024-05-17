'use client';

import { useState } from 'react';
import SelectItemModel from './SelectItemModel';
import SelectToggle from './SelectToggle';
import MenuDropdown from './MenuDropdown';

interface SelectProps {
    placeholder: string;
    data: Array<SelectItemModel>;
    value: SelectItemModel;
    onChange: (selectedItem: SelectItemModel) => void;
}

export default function Select({
    placeholder,
    data,
    value,
    onChange
}: SelectProps) {
    const [isDropdownOpened, setIsDropdownOpened] = useState<boolean>(false);

    function toggleDropdown() {
        setIsDropdownOpened(!isDropdownOpened);
    }

    function closeDropdown() {
        setIsDropdownOpened(false);
    }

    return (
        <div className="relative">
            <SelectToggle
                isDropdownOpened={isDropdownOpened}
                selectedItemMenu={value}
                placeholder={placeholder}
                handleToggleDropdown={toggleDropdown}
            />
            <MenuDropdown
                isDropdownOpened={isDropdownOpened}
                data={data}
                handleCloseDropdown={closeDropdown}
                handleSelectItem={onChange}
            />
        </div>
    );
}
