import { ReactNode } from 'react';

interface SplitedGroupProps {
    children: ReactNode;
}

export default function SplitedGroup({ children }: SplitedGroupProps) {
    return (
        <div className="flex flex-col lg:flex-row gap-y-8 lg:gap-x-6">
            {children}
        </div>
    );
}
