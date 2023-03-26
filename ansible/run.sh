ansible-playbook -i hosts ./playbooks/common/initial.yml
ansible-playbook -i hosts ./playbooks/common/kube-dependencies.yml
ansible-playbook -i hosts ./playbooks/master.yml
ansible-playbook -i hosts ./playbooks/workers.yml