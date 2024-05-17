'use client';

import { useState } from 'react';
import SelectItemModel from './SelectItemModel';
import SelectToggle from './SelectToggle';
import MenuDropdown from './MenuDropdown';

interface SelectProps {
    placeholder: string;
    data: Array<SelectItemModel>;
}

export default function Select({ placeholder, data }: SelectProps) {
    const [isDropdownOpened, setIsDropdownOpened] = useState<boolean>(false);
    const [selectedItem, setSelectedItem] = useState<SelectItemModel>();

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
                selectedItemMenu={selectedItem}
                placeholder={placeholder}
                handleToggleDropdown={toggleDropdown}
            />
            <MenuDropdown
                isDropdownOpened={isDropdownOpened}
                data={data}
                handleCloseDropdown={closeDropdown}
                handleSelectItem={setSelectedItem}
            />
        </div>
    );
}
