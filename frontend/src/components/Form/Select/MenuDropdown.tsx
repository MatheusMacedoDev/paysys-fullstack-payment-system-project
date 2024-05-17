import SelectItemModel from './SelectItemModel';

interface MenuDropdownProps {
    isDropdownOpened: boolean;
    data: Array<SelectItemModel>;
    handleCloseDropdown: () => void;
    handleSelectItem: (menuItem: SelectItemModel) => void;
}

export default function MenuDropdown({
    isDropdownOpened,
    data,
    handleCloseDropdown,
    handleSelectItem
}: MenuDropdownProps) {
    return (
        isDropdownOpened && (
            <div className="absolute left-0 top-[56px] z-50 w-full bg-gray-900 border-green-300 border-2 border-t-0 rounded-bl-3xl rounded-br-2xl flex flex-col overflow-hidden">
                {data.map((menuItem) => {
                    return (
                        <button
                            type="button"
                            className="py-3 hover:bg-green-300 hover:text-green-950"
                            key={menuItem.value}
                            onClick={() => {
                                handleSelectItem(menuItem);
                                handleCloseDropdown();
                            }}
                        >
                            {menuItem.displayText}
                        </button>
                    );
                })}
            </div>
        )
    );
}
