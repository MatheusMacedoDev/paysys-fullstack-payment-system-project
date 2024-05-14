import { ReactNode } from 'react';

interface ContainerProps {
    children: ReactNode;
    onSubmit?: (data: object) => void;
}

export default function Container({ children, onSubmit }: ContainerProps) {
    return (
        <form
            onSubmit={onSubmit}
            className="w-full 2xl:w-3/5 px-8 lg:px-14 py-12 lg:py-16 lg:shadow-[2px_2px_8px_0_rgba(0,0,0,0.2)] lg:rounded-xl bg-gray-900 flex flex-col items-center"
        >
            {children}
        </form>
    );
}
