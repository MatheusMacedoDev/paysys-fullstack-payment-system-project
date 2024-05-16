'use client';

import { faChevronDown, faChevronUp } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

import { useState } from 'react';

interface SelectProps {
    placeholder: string;
    data: Array<SelectItem>;
}

interface SelectItem {
    displayText: string;
    value: string;
}

export default function Select({ placeholder, data }: SelectProps) {
    const [openDropDown, setOpenDropDown] = useState<boolean>(false);
    const [selectedItem, setSelectedItem] = useState<SelectItem>();

    function toggleDropDown() {
        setOpenDropDown(!openDropDown);
    }

    function closeDropDown() {
        setOpenDropDown(false);
    }

    return (
        <div className="relative">
            <div
                onClick={toggleDropDown}
                className={`
                    ${openDropDown ? 'rounded-b-none' : 'rounded-b-full'}
                    ${openDropDown ? 'rounded-t-3xl' : 'rounded-t-full'}
                    bg-gray-900 bg-opacity-0 border-green-300 border-2 w-full h-16 lg:h-14 px-8 flex items-center justify-between cursor-pointer
                `}
            >
                <p className="text-xl font-light text-green-300 select-none">
                    {selectedItem ? selectedItem.displayText : placeholder}
                </p>
                {openDropDown ? (
                    <FontAwesomeIcon size="lg" icon={faChevronUp} />
                ) : (
                    <FontAwesomeIcon size="lg" icon={faChevronDown} />
                )}
            </div>
            {openDropDown && (
                <div className="absolute left-0 top-[56px] z-50 w-full bg-gray-900 border-green-300 border-2 border-t-0 rounded-bl-3xl rounded-br-2xl flex flex-col overflow-hidden">
                    {data.map((item) => {
                        return (
                            <button
                                type="button"
                                className="py-3 hover:bg-green-300 hover:text-green-950"
                                key={item.value}
                                onClick={() => {
                                    setSelectedItem(item);
                                    closeDropDown();
                                }}
                            >
                                {item.displayText}
                            </button>
                        );
                    })}
                </div>
            )}
        </div>
    );
}
