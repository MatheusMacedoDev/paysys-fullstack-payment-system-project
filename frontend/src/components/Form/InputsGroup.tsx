import { ReactNode } from 'react';

interface InputsGroupProps {
    children: ReactNode;
}

export default function InputsGroup({ children }: InputsGroupProps) {
    return <div className="w-full my-20 flex flex-col gap-y-8">{children}</div>;
}
